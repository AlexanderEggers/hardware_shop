/*
Server.js
Erstellt von Linh Do
verwendete Quelle: https://www.codementor.io/nodejs/tutorial/build-website-from-scratch-using-expressjs-and-bootstrap
 */


//loading the dependencies
var express = require("express");
var app = express();
var router = express.Router();
//in the folder 'views' are the html-files
var path = __dirname + '/views/';


//defined the Router middle layer, which will be executed before any other routes.
//This route will be used to print the type of HTTP request the particular Route
//is referring to.
router.use(function (req,res,next) {
    console.log("/" + req.method);
    //Once the middle layer is defined, you must pass "next()"
    //so that next router will get executed.
    next();
});

//sendFile()" function is for sending files to a web browser
router.get("/",function(req,res){
    res.sendFile(path + "index.html");
});

router.get("/wishlist",function(req,res){
    res.sendFile(path + "wishlist.html");
});

router.get("/contact",function(req,res){
    res.sendFile(path + "contact.html");
});

//use the Routes we have defined above
app.use("/",router);
app.use(express.static('views'));

//we can assign the routes in order, so the last one will
//get executed when the incoming request is not matching any route.
//in this case its the 404.html
app.use("*",function(req,res){
    res.sendFile(path + "404.html");
});

app.listen(3000,function(){
    console.log("Live at Port 3000");
});







var sqlite3 = require('sqlite3').verbose();
var dbFile = "./DB.sql";
var db = new sqlite3.Database(dbFile);

var posts = [];
db.serialize(function() {
    db.each("SELECT id, category FROM article", function(err, row) {
        console.log(row.id + ": " + row.id + " " + row.category);
        posts.push({id: row.id, category: row.category})
    }, function() {
        // All done fetching records, render response
        console.log("dynamic", {title: "Dynamic", posts: posts})
    })
});
db.close();
exports.postsExp =  posts;





