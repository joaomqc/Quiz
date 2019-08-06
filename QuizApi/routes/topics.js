var express = require('express');
var router = express.Router();
var quizManagementRepository = require('../repositories/quiz_management_repository');

/* GET topics. */
router.get('/', function (req, res, next) {
    quizManagementRepository.getAllTopics(function (err, message) {
        if (err) next(err);
        else res.send({
            topics: message.Topics.map(topic => {
                return {
                    topicId: topic.TopicId,
                    name: topic.Name,
                    description: topic.Description,
                    url: topic.Url
                }
            })
        });
    });
});

/* GET topic. */
router.get('/:topicId', function (req, res, next) {
    quizManagementRepository.getTopicById(req.params.topicId, function (err, message) {
        if (err) next(err);
        else res.send(message);
    });
});

module.exports = router;
