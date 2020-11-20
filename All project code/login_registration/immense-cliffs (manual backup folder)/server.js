const express = require('express');
const app = express();
const {pool} = require("./dbConfig")
const PORT = process.env.PORT || 4000;
const bcrypt = require('bcrypt');
const session = require('express-session');
const flash = require('express-flash');
const passport = require('passport');



const initializePassport = require('./passportConfig')
initializePassport(passport);

app.set('view engine','ejs');

app.use(express.urlencoded({ extended: 'false'}));

app.use(express.static(__dirname,'/public/'));

app.use(session({
	secret: 'secret',

	resave: false,

	saveUninitialized: false
	})
);
app.use(passport.initialize())
app.use(passport.session())

app.use(flash());


app.get('/', (req,res)=> {
	res.render('login');
});

app.get('/register', checkAuthenticated, (req,res) => {
	res.render('register');
});

app.get('/login', checkAuthenticated, (req,res) => {
	res.render('login');
});

app.get('/dashboard',checkNotAuthenticated, (req,res) => {
	res.render('dashboard',{ user: req.user.name});
});

app.get('/tanks',(req,res)=>{res.render('index')});

app.get('/logout', (req,res)=> {
	req.logOut();
	req.flash('success_msg', 'You have logged out.')
	res.redirect("/login")
})

app.get('/test', (req,res)=> {
	res.render('index')
	req.flash('success_msg', "something went right...?")
})

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
	};
}

if (errors.length > 0) {
	res.render("register", { errors} );
}else{
		//validation passed

		let hashedPassword = await bcrypt.hash(password, 10);
		console.log(hashedPassword);

		pool.query(
			"SELECT * FROM users WHERE email = $1", [email],(err,results)=>{
				if (err) {
					console.log('here')
				}

				console.log(results.rows);

				if (results.rows.length > 0) {
					errors.push({message: "email already registered"});
					res.render('register', {errors})
				}else{
					pool.query(
						'INSERT INTO users (name, email, password) VALUES ($1, $2, $3) RETURNING id, password', [name,email,hashedPassword], (err,results) => {
							if (err) {
								throw err;
							}

							console.log(results.rows);
							req.flash('success_msg', "You are now registered, please login")
							res.redirect('/login')
						}
					)
				}
			}
			)
	}

});

app.post("/login",passport.authenticate('local',{
	successRedirect : "/dashboard",
	failureRedirect: "/login",
	failureFlash: true
}));

function checkAuthenticated(req,res,next){
	if (req.isAuthenticated()) {
		return res.redirect('/dashboard')
	}
	return next();
}

function checkNotAuthenticated(req,res,next){
	if (req.isAuthenticated()) {
		return next();
	}
	res.redirect('/login')
}




app.listen(process.env.PORT, ()=> {
	console.log(`server running on port ${PORT}`);
});