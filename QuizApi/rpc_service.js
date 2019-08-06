var grpc = require('grpc');
var proto_loader = require('@grpc/proto-loader');
var config = require('./shared/config');

const PROTO_DIR = __dirname + config.proto.contracts_dir;
const PROTO_OPTIONS = {
    keepCase: false,
    longs: Number,
    enums: String,
    defaults: true,
    oneofs: true,
    includeDirs: [
        PROTO_DIR
    ]
};

module.exports.setupQuizzesClient = function () {
    var packageDefinition = proto_loader.loadSync(
        config.proto.quizzes_proto_path,
        PROTO_OPTIONS
    );
    var quizzes_proto = grpc.loadPackageDefinition(packageDefinition).Shared.Contracts.QuizManagement.Quizzes;
    var url = 'localhost:' + config.rpc.quiz_management_port;
    var client = new quizzes_proto.QuizzesService(url, grpc.credentials.createInsecure());
    return client;
}

module.exports.setupTopicsClient = function () {
    var packageDefinition = proto_loader.loadSync(
        config.proto.topics_proto_path,
        PROTO_OPTIONS
    );
    var quizzes_proto = grpc.loadPackageDefinition(packageDefinition).Shared.Contracts.QuizManagement.Topics;
    var url = 'localhost:' + config.rpc.quiz_management_port;
    var client = new quizzes_proto.TopicsService(url, grpc.credentials.createInsecure());
    return client;
}

module.exports.setupUsersClient = function () {
    var packageDefinition = proto_loader.loadSync(
        config.proto.users_proto_path,
        PROTO_OPTIONS
    );
    var users_proto = grpc.loadPackageDefinition(packageDefinition).Shared.Contracts.UserManagement.Users;
    var url = 'localhost:' + config.rpc.user_management_port;
    var client = new users_proto.UsersService(url, grpc.credentials.createInsecure());
    return client;
}