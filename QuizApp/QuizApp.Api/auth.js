var jwt = require('jsonwebtoken');
var config = require('./shared/config');

const headerKey = 'Bearer';

module.exports.ensureToken = function (req, res, next) {
    var header = req.headers.authorization;
    if(header){
        const parts = req.headers.authorization.split(' ');
        if (parts.length === 2 && parts[0] === headerKey) {
            const token = parts[1];

            return jwt.verify(token, config.jwt.secret, function(err, decoded){
                if(err){
                    res.sendStatus(401);
                }else{
                    req.token = token;
                    req.decoded = decoded;
                    next();
                }
            });
        }
    }
    return res.sendStatus(401);
}