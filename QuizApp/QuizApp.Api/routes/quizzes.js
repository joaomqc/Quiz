var express = require('express');
var router = express.Router();
var quizManagementRepository = require('../repositories/quiz_management_repository');

/* GET quizzes paged. */
router.get('/', function(req, res, next) {
  quizManagementRepository.getQuizzesPaged(req.query.startIndex, req.query.itemCount, function(err, message){
    if(err) next(err);
    res.send(message);
  });
});

/* GET quiz. */
router.get('/:quizId', function(req, res, next){
  quizManagementRepository.getQuiz(req.params.quizId, function(err, message){
    if(err) next(err);
    res.send(message);
  });
});

/* GET quizzes by user paged. */
router.get('/user/:userId', function(req, res, next) {
  quizManagementRepository.getQuizzesByUserPaged(req.params.userId, req.query.startIndex, req.query.itemCount, function(err, message){
    if(err) next(err);
    res.send(message);
  });
});

/* GET public quizzes by user paged. */
router.get('/user/:userId/public', function(req, res, next) {
  quizManagementRepository.getPublicQuizzesByUserPaged(req.params.userId, req.query.startIndex, req.query.itemCount, function(err, message){
    if(err) next(err);
    res.send(message);
  });
});

/* GET quizzes by topic paged. */
router.get('/topic/:topicId', function(req, res, next) {
  quizManagementRepository.getQuizzesByTopicPaged(req.params.topicId, req.query.startIndex, req.query.itemCount, function(err, message){
    if(err) next(err);
    res.send(message);
  });
});

/* POST quiz. */
router.post('/', function(req, res, next) {
  quizManagementRepository.createQuiz(req.body, function(err, message){
    if(err) next(err);
    res.send(message);
  });
});

/* DELETE quiz. */
router.delete('/:quizId', function(req, res, next) {
  quizManagementRepository.deleteQuiz(req.params.quizId, function(err, message){
    if(err) next(err);
    res.send(message);
  });
});

/* DELETE quizzes by user. */
router.delete('/user/:userId', function(req, res, next) {
  quizManagementRepository.deleteQuizzesByUser(req.params.userId, function(err, message){
    if(err) next(err);
    res.send(message);
  });
});

module.exports = router;
