const express = require('express');
const mysql = require('mysql');
const multer = require('multer');
const cors = require('cors');
const bodyParser = require('body-parser');
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');

const app = express();

// Middleware
app.use(cors());
app.use(express.json());
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

// Database connection
const db = mysql.createConnection({
  host: 'localhost',
  user: 'root',
  password: '',
  database: 'evaluation',
});

db.connect((err) => {
  if (err) throw err;
  console.log('Connected to MySQL database');
});

/// Generate a random secret key
//const SECRET_KEY = crypto.randomBytes(32).toString('hex');
const SECRET_KEY ='72355080169';
// Token verification middleware
const verifyToken = (req, res, next) => {
  const token = req.headers.authorization;
  
  if (!token) {
    return res.status(401).send({ error: 'No token provided' });
  }

  jwt.verify(token, SECRET_KEY, (err, decoded) => {
    if (err) {
      return res.status(401).send({ error: 'Invalid token' });
    }
    next();
  });
};

// Create account endpoint
app.post('/create-account', (req, res) => {
  const { first_name, last_name,birth_date, username, password, account_role } = req.query;
  if (!first_name || !last_name || !birth_date || !username || !password || !account_role) {
    res.status(400).send({ error: 'Missing parameter or role ID error' });
    return;
  }

  const token = jwt.sign({ username }, SECRET_KEY); // Generate JWT token

  bcrypt.hash(password, 10, (err, hashedPassword) => {
    if (err) {
      console.error('Error hashing password:', err);
      res.status(500).send({ error: 'Error creating account' });
      return;
    }

    const query =
      'INSERT INTO `user_info`(`first_name`, `last_name`, `birth_date`, `username`, `password`, `account_role`, `token`) VALUES (?,?,?,?,?,?,?)';

    db.query(query, [first_name, last_name,birth_date, username, hashedPassword, account_role, token], (err, result) => {
      if (err) {
        console.error('Error creating account:', err);
        res.status(500).send({ error: 'Error creating account' });
      } else {
        res.status(200).send({ message: 'Account created successfully' });
      }
    });
  });
});


app.put('/update-account', (req, res) => {
  const { first_name, last_name,birth_date, username, password, account_role, users_id } = req.query;

  if (!first_name || !last_name || !birth_date || !username || !password || !account_role) {
    res.status(400).send({ error: 'Missing parameter or role ID error' });
    return;
  }


  bcrypt.hash(password, 10, (err, hashedPassword) => {
    if (err) {
      console.error('Error hashing password:', err);
      res.status(500).send({ error: 'Error creating account' });
      return;
    }

    const query =
    "UPDATE `user_info` SET `first_name`= ?,`last_name`= ?,`birth_date`= ?,`username`= ?,`password`= ?,`account_role`= ? WHERE users_id = ?";
    db.query(query, [first_name, last_name,birth_date, username, hashedPassword, account_role, users_id], (err, result) => {
      if (err) {
        console.error('Error creating account:', err);
        res.status(500).send({ error: 'Error updating account' });
      } else {
        res.status(200).send({ message: 'Account updated successfully' });
      }
    });
  });
});

// Login endpoint
app.post('/login', (req, res) => {
  const { username, password } = req.query;
console.log(req.query);
  if (!username || !password) {
    res.status(400).send({ error: 'Missing username or password' });
    return;
  }

  const query =
  "SELECT  * FROM `user_info` WHERE username = ?";

  db.query(query, [username], (err, result) => {
    if (err) {
      res.status(500).send({ error: 'Error fetching data' });
      return;
    }
    if (result.length === 0) {
      res.status(401).send({ error: 'Invalid credentials' });
      return;
    }
    const hashedPassword = result[0].password;
    bcrypt.compare(password, hashedPassword, (err, passwordMatch) => {
      if (err) {
        res.status(500).send({ error: 'Error logging in' });
        return;
      }

      if (passwordMatch) {
        res.status(200).send(result);
      } else {
        res.status(401).send({ error: 'Invalid password' });
      }
    });
  });
});
app.get('/getRole', (req, res) => {
  const sqlQuery = "SELECT `account_role_id` as RoleId, `action_role` as ActionRole FROM `account_role`";
  db.query(sqlQuery, (err, result) => {
    if (err) {
      res.status(500).send({ error: 'Error fetching data' });
    } else {
      res.status(200).send(result);
    }
  });
});


app.get('/evaluation', verifyToken, (req, res) => {
  const displayData = req.query.displayData;
  if (!displayData.trim()  ) {
    res.status(400).send({ error: 'Invalid or missing Parameter' });
    return;
  } 
  let sqlQuery;
  if (displayData === "Commitment") {
    sqlQuery = "SELECT `Questions` FROM commitment";
 
  } else if (displayData === "Knowledge") {
      sqlQuery =  "SELECT `Questions` FROM knowledge_of_subject"
  } else if (displayData === "Teaching") {
      sqlQuery =  "SELECT `Questions` FROM teaching_for_independent_learning"
  } else if (displayData === "Management") {
      sqlQuery =  "SELECT `Questions` FROM management_of_learning"
  } else if (displayData === "User info") {
      sqlQuery = "SELECT  * FROM `user_info`"
  } else {
    return res.status(400).send({ error: 'Invalid displayData value' });
  }
  db.query(sqlQuery, (err, result) => {
    if (err) {
      res.status(500).send({ error: 'Error fetching data' });
    } else {
      res.status(200).send(result);
    }
  });
  
});


app.get('/search', verifyToken, (req, res) => {
  let {displayData,searchData}=req.query;
  if (!displayData.trim()  || !searchData.trim() ) {
    res.status(400).send({ error: 'Invalid or missing Parameter' });
    return;
  }
  let sqlQuery;
  if (displayData === "Search") {
    sqlQuery = "SELECT users_id,concat(`first_name`, ' ', `last_name`) as name FROM `user_info` WHERE account_role = ?";
  } else if (displayData === "Report") {
    sqlQuery = "SELECT concat (first_name,' ',last_name) as name,`total_evaluation_score`, `total_evaluation_item` FROM `user_info` WHERE account_role='Admin' and users_id= ? GROUP by name";
  }

  else {
    return res.status(400).send({ error: 'Invalid displayData value' });
  }
  db.query(sqlQuery,[searchData], (err, result) => {
    if (err) {
      res.status(500).send({ error: 'Error fetching data' });
    } else {
      res.status(200).send(result);
    }
  });
});


app.delete('/evaluation', verifyToken, (req, res) => {
  const {id,tableName}= req.query;
  console.log(id, tableName);
  let sqlQuery;
  if (!Id || isNaN(Id) || !tableName) {
    res.status(400).send({ error: 'Invalid or missing Parameter' });
    return;
  }
  if(tableName===""){
    sqlQuery = " ";
  }
  
  else {
    return res.status(400).send({ error: 'Invalid table name' });
  }
  db.query(sqlQuery, [Id], (err, result) => {
    if (err) {
      res.status(500).send({ error: 'Error' });
    } else {
      res.status(200).send({ message: 'Successfully deleted' });
    }
  });
});

app.put('/evaluation', verifyToken, (req, res) => {
  const id=req.query.id;
  const tableName=req.query.tableName;

  if ( !id.trim()  || isNaN(id) || !tableName.trim() ) {
    res.status(400).send({ error: "Missing parameter or id error" });
    return;
  }

  if(tableName==="User Info"){
    const {first_name,last_name,birth_date,username,password,account_role} = req.query;
    if (!first_name || !last_name || !birth_date || !username || !password || !account_role) {
      res.status(400).send({ error: "Missing parameter " });
      return;
    }
    const query = " UPDATE `user_info` SET `first_name`= ?,`last_name`= ?,`birth_date`= ?,`username`= ?,`password`= ?,`account_role`= ?  WHERE users_id = ?";
    db.query(query, [first_name,last_name,birth_date,username,password,account_role,id], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully updated' });
      }
    });
  }
  else if(tableName==="Score"){
    const {total_evaluation_score,total_evaluation_item} = req.query;
    if (  !total_evaluation_score || !total_evaluation_item) {
      res.status(400).send({ error: "Missing parameter or id error" });
      return;
    }
    const query = "UPDATE `user_info` SET `total_evaluation_score`=total_evaluation_score+ ?,`total_evaluation_item`=total_evaluation_item+ ? WHERE users_id = ?";
    db.query(query, [total_evaluation_score,total_evaluation_item,id], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully updated' });
      }
    });
  }
  else{
    return res.status(400).send({ error: 'Invalid table name' });
  }
});


app.post('/evaluation', verifyToken, (req, res) => {
  const tableName=req.query.tableName;
  console.log(tableName);
  if(tableName === "User Info"){
    const {first_name,last_name,birth_date,username,password,account_role} = req.query;
    if (!first_name || !last_name || !birth_date || !username || !password || !account_role) {
      res.status(400).send({ error: "Missing parameter" });
      return;
    }
    const query = "INSERT INTO `user_info`(first_name,last_name,birth_date,username,password,account_role) VALUES (?,?,?,?,?,?)";
    db.query(query, [first_name,last_name,birth_date,username,password,account_role], (err, result) => {
      if (err) {
        res.status(500).send({ error: 'Error' });
      } else {
        res.status(200).send({ message: 'Successfully inserted' });
      }
    });
  
  }
  else{
    return res.status(400).send({ error: 'Invalid table name' });
  }
});

app.listen(3000, () => {
  console.log('Server running on port 3000');
});
