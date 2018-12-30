var rpc_service = require('../rpc_service');
var client = rpc_service.setupQuizzesClient();

module.exports.getQuizzesPaged = function (startIndex, itemCount, callback) {
    client.getQuizzesPaged({startIndex, itemCount}, function(err, response){
        callback(err, response && response.message);
    });
}

module.exports.getQuiz = function (quizId, callback){
    client.getQuiz({quizId}, function(err, response){
        callback(err, response && response.message);
    });
}

module.exports.getQuizzesByUserPaged = function (userId, startIndex, itemCount, callback){
    client.getQuizzesByUserPaged({userId, pageInfo: {startIndex, itemCount}}, function(err, response){
        callback(err, response && response.message);
    });
}

module.exports.getPublicQuizzesByUserPaged = function(userId, startIndex, itemCount, callback){
    client.getPublicQuizzesByUserPaged({userId, pageInfo: {startIndex, itemCount}}, function(err, response){
        callback(err, response && response.message);
    });
}

module.exports.getQuizzesByTopicPaged = function(topicId, startIndex, itemCount, callback){
    client.getQuizzesByTopicPaged({topicId, pageInfo: {startIndex, itemCount}}, function(err, response){
        callback(err, response && response.message);
    });
}

module.exports.createQuiz = function(quiz, callback){
    client.createQuiz(quiz, function(err, response){
        callback(err, response && response.message);
    });
}

module.exports.deleteQuiz = function(quizId, callback){
    client.deleteQuiz({quizId}, function(err, response){
        callback(err, response && response.message);
    });
}

module.exports.deleteQuizzesByUser = function(userId, keepPublic, callback){
    client.deleteQuizzesByUser({userId, keepPublic}, function(err, response){
        callback(err, response && response.message);
    });
}