var rpc_service = require('../rpc_service');
var client = rpc_service.setupTopicsClient();

module.exports.getAllTopics = function (callback) {
    client.getAllTopics({}, function(err, response){
        callback(err, response && response.message);
    });
}

module.exports.getTopicById = function(topicId, callback){
    client.getTopicById({topicId}, function(err, response){
        callback(err, response && response.message);
    });
}