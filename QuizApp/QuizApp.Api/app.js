const createError = require('http-errors');
const express = require('express');
const logger = require('morgan');
const bodyparser = require('body-parser');
const cors = require('cors');
const grpcHelpers = require('./shared/grpc_helpers');

const quizzesRouter = require('./routes/quizzes');
const topicsRouter = require('./routes/topics');
const usersRouter = require('./routes/users');

const app = express();

app.use(cors());
app.use(logger('dev'));
app.use(bodyparser.urlencoded({ extended: false }));
app.use(bodyparser.json());

app.use('/api/users', usersRouter);
app.use('/api/quizzes', quizzesRouter);
app.use('/api/topics', topicsRouter);

// catch 404 and forward to error handler
app.use(function (req, res, next) {
    next(createError(404));
});

// error handler
app.use(function (err, req, res, next) {
    const errorStatus = grpcHelpers.grpcStatusMap(err.code) || err.status;

    res.status(errorStatus || 500);
    res.send(req.app.get('env') === 'development' ? err : {});
});

module.exports = app;
