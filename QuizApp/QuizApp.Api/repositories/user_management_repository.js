var rpc_service = require('../rpc_service');
var usersClient = rpc_service.setupUsersClient();

module.exports.getUserById = function (userId, callback){
    usersClient.getUserById({
        UserId: userId
    }, function(err, response){
        callback(err, response && response.message);
    });
}

module.exports.registerUser = function (user, callback) {
    usersClient.registerUser({
        Username: user.username,
        Email: user.email,
        Password: user.password
    }, function(err, response){
        callback(err, response && response.message);
    });
}

module.exports.authenticateUser = function(user, callback) {
    usersClient.authenticateUser({
        Username: user.username,
        Password: user.password
    }, function(err, response){
        callback(err, response && response.message);
    });
}