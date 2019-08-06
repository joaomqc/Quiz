var express = require('express');
var router = express.Router();
var quizManagementRepository = require('../repositories/quiz_management_repository');

const auth = require('../auth');

/* GET quizzes paged. */
router.get('/', function (req, res, next) {
    quizManagementRepository.getQuizzesPaged(req.query.startIndex || 0, req.query.itemCount || 10, function (err, message) {
        if (err) next(err);
        else res.send({
            pageInfo: {
                itemCount: message.PageInfo.ItemCount,
                startIndex: message.PageInfo.StartIndex,
                endIndex: message.PageInfo.EndIndex,
                totalCount: message.PageInfo.TotalCount
            },
            quizzes: message.Quizzes.map(quiz => {
                return {
                    id: quiz.Id,
                    name: quiz.Name,
                    creationTimestamp: quiz.CreationTimestamp,
                    userId: quiz.UserId,
                    topic: {
                        id: quiz.Topic.Id,
                        name: quiz.Topic.Name
                    },
                    isPublic: quiz.IsPublic
                };
            })
        });
    });
});

/* GET quiz. */
router.get('/:quizId(\\d+)', function (req, res, next) {
    quizManagementRepository.getQuiz(req.params.quizId, function (err, message) {
        if (err) next(err);
        else res.send(message);
    });
});

/* GET public quizzes by user paged. */
router.get('/user/:userId', function (req, res, next) {
    quizManagementRepository.getPublicQuizzesByUserPaged(req.params.userId, req.query.startIndex, req.query.itemCount, function (err, message) {
        if (err) next(err);
        else res.send(message);
    });
});

/* GET quizzes by topic paged. */
router.get('/topic/:topicId', function (req, res, next) {
    quizManagementRepository.getQuizzesByTopicPaged(req.params.topicId, req.query.startIndex, req.query.itemCount, function (err, message) {
        if (err) next(err);
        else res.send(message);
    });
});

/* POST quiz. */
router.post('/', function (req, res, next) {
    quizManagementRepository.createQuiz(req.body, function (err, message) {
        if (err) next(err);
        else res.send(message);
    });
});

/* DELETE quiz. */
router.delete('/:quizId', function (req, res, next) {
    quizManagementRepository.deleteQuiz(req.params.quizId, function (err, message) {
        if (err) next(err);
        else res.send(message);
    });
});

/* DELETE quizzes by user. */
router.delete('/user/:userId', function (req, res, next) {
    quizManagementRepository.deleteQuizzesByUser(req.params.userId, function (err, message) {
        if (err) next(err);
        else res.send(message);
    });
});

router.use(auth.ensureToken);

/* GET quizzes by user paged. */
router.get('/user/', function (req, res, next) {
    const userId = req.decoded.sub;

    quizManagementRepository.getQuizzesByUserPaged(userId, req.query.startIndex || 0, req.query.itemCount || 10, function (err, message) {
        if (err) next(err);
        else res.send(message);
    });
});

module.exports = router;
