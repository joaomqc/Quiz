var express = require('express');
var router = express.Router();
var userManagementRepository = require('../repositories/user_management_repository');

/* GET user. */
router.get('/:userId', function(req, res, next) {
  userManagementRepository.getUserById(req.params.userId, function(err, message){
    if(err) next(err);
    res.send(message);
  });
});

/* POST user. */
router.get('/', function(req, res, next){
  userManagementRepository.registerUser(req.body, function(err, message){
    if(err) next(err);
    res.send(message);
  });
});

/* POST authentication. */
router.get('/auth', function(req, res, next){
  userManagementRepository.authenticateUser(req.body, function(err, message){
    if(err) next(err);
    res.send(message);
  });
});

module.exports = router;
