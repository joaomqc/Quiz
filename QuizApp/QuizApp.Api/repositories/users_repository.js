var rpc_service = require('../rpc_service');
var client = rpc_service.setupUsersClient();

module.exports.GetUserById = function (userId, callback){
    client.GetUserById({userId}, function(err, response){
        callback(err, response && response.message);
    });
}

module.exports.RegisterUser = function (user, callback) {
    client.RegisterUser(user, function(err, response){
        callback(err, response && response.message);
    });
}

module.exports.AuthenticateUser = function(userId, callback) {
    client.AuthenticateUser(userId, function(err, response){
        callback(err, response && response.message);
    });
}