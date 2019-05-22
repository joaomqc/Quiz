var express = require('express');
var router = express.Router();
var validator = require('validator');
var userManagementRepository = require('../repositories/user_management_repository');

const auth = require('../auth');

/* POST user. */
router.post('/', function (req, res, next) {
    if(!req.body.email || !validator.isEmail(req.body.email) ||
      !req.body.username || !req.body.username.trim() ||
      !req.body.password || !req.body.password.trim()){
        return res.sendStatus(400);
    }
    
    userManagementRepository.registerUser(req.body, function (err, message) {
        if (err) next(err);
        else res.send(message);
    });
});

/* POST authentication. */
router.post('/auth', function (req, res, next) {
    if(!req.body.username || !req.body.username.trim() ||
     !req.body.password || !req.body.password.trim()){
        return res.sendStatus(400);
    }

    userManagementRepository.authenticateUser(req.body, function (err, message) {
        if(err) next(err)
        else res.send({
            accessToken: message.AccessToken,
            expiresIn: message.ExpiresIn
        });
    });
});

router.use(auth.ensureToken);

/* GET user. */
router.get('/', function (req, res, next) {
    const userId = req.decoded.sub;

    if(!validator.isUUID(userId)){
        res.sendStatus(400);
    }else{
        userManagementRepository.getUserByUserId(userId, function (err, message) {
            if (err) next(err);
            else res.send({
                email: message.Email,
                username: message.Username
            });
        });
    }
});

module.exports = router;
