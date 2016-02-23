/*
Server.js
Erstellt von Linh Do
verwendete Quelle: https://www.codementor.io/nodejs/tutorial/build-website-from-scratch-using-expressjs-and-bootstrap
 */


//loading the dependencies
var bodyParser = require("body-parser");
var express = require("express");
var app = express();
var router = express.Router();
//in the folder 'views' are the html-files
var path = __dirname + '/views/';

//tell Express to use bodyparser as middle-ware
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

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
    var searchstring = req.body.searchstring;
    console.log(searchstring);
});

router.get("/wishlist",function(req,res){
    res.sendFile(path + "wishlist.html");
});

router.get("/contact",function(req,res){
    res.sendFile(path + "contact.html");
});

//use the Routes we have defined above
app.use("/",router);

//we can assign the routes in order, so the last one will
//get executed when the incoming request is not matching any route.
//in this case its the 404.html
app.use("*",function(req,res){
    res.sendFile(path + "404.html");
});

app.listen(3000,function(){
    console.log("Live at Port 3000");
});

/*
function toggleNext(el) {
    var next=el.nextSibling;
    while(next.nodeType != 1) next=next.nextSibling;
    next.style.display=((next.style.display=="none") ? "block" : "none");
}

function toggleNextById(el) {
    var ccn="clicker";
    var clicker=document.getElementById(el);
    clicker.className+=" "+ccn;
    clicker.onclick=function() {toggleNext(this)}
    toggleNext(clicker);

}
*/


