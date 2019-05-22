var rpc_service = require('../rpc_service');
var usersClient = rpc_service.setupUsersClient();

module.exports.getUserByUserId = function (userId, callback) {
    usersClient.getUserByUserId({
        UserId: userId
    }, callback);
}

module.exports.registerUser = function (user, callback) {
    usersClient.registerUser({
        Username: user.username,
        Email: user.email,
        Password: user.password
    }, callback);
}

module.exports.authenticateUser = function (user, callback) {
    usersClient.authenticateUser({
        Username: user.username,
        Password: user.password
    }, callback);
}