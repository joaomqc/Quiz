const createError = require('http-errors');
const express = require('express');
const logger = require('morgan');
const bodyparser = require('body-parser');
const cors = require('cors');

const quizzesRouter = require('./routes/quizzes');
const topicsRouter = require('./routes/topics');
const usersRouter = require('./routes/users');

const app = express();

app.use(cors());
app.use(logger('dev'));
app.use(bodyparser.urlencoded({ extended: false }));
app.use(bodyparser.json());

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
  res.send();
});

module.exports = app;
