require("dotenv").config();

const {Pool} = require("pg");

const isProduction = process.env.NODE_ENV === "production";

const connectionString = `postgresql://${process.env.DB_USER}:${process.env.DB_PASSWORD}@${process.env.DB_HOST}:${process.env.DB_PORT}/${process.env.DB_DATABASE}`

//const connectionString = `postgres://pqmlletlyzirwe:2de41a8a70e5983a609855993b5d09541dfa686b476547380acc1e0a16e05e6a@ec2-52-86-116-94.compute-1.amazonaws.com:5432/db2fc4u3q76ult`


// const pool = new Pool ({
// 	connectionString: isProduction ? process.env.DATABASE_URL : connectionString

// });
const pool = new Pool ({
	connectionString: process.env.DATABASE_URL
})


module.exports = { pool };