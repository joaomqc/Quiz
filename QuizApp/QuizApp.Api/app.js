var createError = require('http-errors');
var express = require('express');
var path = require('path');
var logger = require('morgan');
var bodyparser = require('body-parser');
var cors = require('cors');

var quizzesRouter = require('./routes/quizzes');
var topicsRouter = require('./routes/topics');
var usersRouter = require('./routes/users');

require('./repositories/quizzes_repository');
require('./repositories/users_repository');

var app = express();

app.use(cors());
app.use(logger('dev'));
app.use(bodyparser.urlencoded({ extended: false }));
app.use(bodyparser.json());
app.use(express.static(path.join(__dirname, 'public')));

app.use('/quizzes', quizzesRouter);
app.use('/topics', topicsRouter);
app.use('/users', usersRouter);

// catch 404 and forward to error handler
app.use(function(req, res, next) {
  next(createError(404));
});

// error handler
app.use(function(err, req, res, next) {
  // set locals, only providing error in development
  res.locals.message = err.message;
  res.locals.error = req.app.get('env') === 'development' ? err : {};

  // render the error page
  res.status(err.status || 500);
  res.render('error');
});

module.exports = app;
