var rpc_service = require('../rpc_service');
var quizzesClient = rpc_service.setupQuizzesClient();
var topicsClient = rpc_service.setupTopicsClient();

module.exports.getQuizzesPaged = function (startIndex, itemCount, callback) {
    quizzesClient.getQuizzesPaged({
        StartIndex: startIndex,
        ItemCount: itemCount
    }, function (err, response) {
        callback(err, response && response.message);
    });
}

module.exports.getQuiz = function (quizId, callback) {
    quizzesClient.getQuiz({
        QuizId: quizId
    }, function (err, response) {
        callback(err, response && response.message);
    });
}

module.exports.getQuizzesByUserPaged = function (userId, startIndex, itemCount, callback) {
    quizzesClient.getQuizzesByUserPaged({
        UserId: userId,
        PageInfo: {
            StartIndex: startIndex,
            ItemCount: itemCount
        }
    }, callback);
}

module.exports.getPublicQuizzesByUserPaged = function (userId, startIndex, itemCount, callback) {
    quizzesClient.getPublicQuizzesByUserPaged({
        UserId: userId,
        PageInfo: {
            StartIndex: startIndex,
            ItemCount: itemCount
        }
    }, callback);
}

module.exports.getQuizzesByTopicPaged = function (topicId, startIndex, itemCount, callback) {
    quizzesClient.getQuizzesByTopicPaged({
        TopicId: topicId,
        PageInfo: {
            StartIndex: startIndex,
            ItemCount: itemCount
        }
    }, callback);
}

module.exports.createQuiz = function (quiz, callback) {
    quizzesClient.createQuiz({
        Name: quiz.name,
        UserId: quiz.UserId,
        Questions: quiz.questions.map(
            question => {
                return {
                    Text: question.text,
                    IsMultipleChoice: question.isMultipleChoice,
                    Answers: question.answers.map(
                        answer => {
                            return {
                                Text: answer.text,
                                IsCorrect: answer.isCorrect
                            }
                        }
                    )
                }
            }
        ),
        TopicId: quiz.topicId,
        IsPublic: quiz.isPublic
    }, callback);
}

module.exports.deleteQuiz = function (quizId, callback) {
    quizzesClient.deleteQuiz({
        QuizId: quizId
    }, callback);
}

module.exports.deleteQuizzesByUser = function (userId, keepPublic, callback) {
    quizzesClient.deleteQuizzesByUser({
        UserId: userId,
        KeepPublic: keepPublic
    }, callback);
}

module.exports.getAllTopics = function (callback) {
    topicsClient.getAllTopics({}, callback);
}

module.exports.getTopicById = function (topicId, callback) {
    topicsClient.getTopicById({
        TopicId: topicId
    }, callback);
}