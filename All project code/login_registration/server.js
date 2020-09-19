const express = require('express');
const app = express();
const {pool} = require("./dbConfig")
const PORT = process.env.PORT || 4000;
const bcrypt = require('bcrypt');
app.set('view engine','ejs');

app.use(express.urlencoded({ extended: 'false'}));

app.get('/', (req,res)=> {
	res.render('index');
});

app.get('/register',(req,res) => {
	res.render('register');
});

app.get('/login',(req,res) => {
	res.render('login');
});

app.get('/dashboard',(req,res) => {
	res.render('dashboard',{ user: "ryan"});
});

app.post('/register', async (req,res) => { 

let {name,email,password,password2}= req.body

console.log({name,email,password,password2});

let errors = [];

if (!name || !email || !password || !password2){
	errors.push({message: "Please Enter all Fields."});
};

if (password && password2) {
	if (password.length < 6) {
		errors.push({message: "Password should be at least 6 characters."});
	}

	if (password != password2) {
		errors.push({message: "Passwords do not match!"});
	}else{
		//validation passed

		let hashedPassword = await bcrypt.hash(password, 10);
		console.log(hashedPassword);

		pool.query(
			`SELECT * FROM users WHERE email = $1`, {email},(err,results)=>{
				if (err) {
					throw err;
				}

				console.log(results.rows);
			}
			)
	}
}
if (errors.length > 0) {
	res.render("register", { errors} );
};

});


app.listen(PORT, ()=> {
	console.log(`server running on port ${PORT}`);
});