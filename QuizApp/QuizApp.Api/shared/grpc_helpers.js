const GRPCStatusCodes = {
    InvalidArgument: 3,
    Unauthorized: 16
};

const HTTPStatusCodes = {
    BadRequest: 400,
    Unauthorized: 401
};


module.exports.grpcStatusMap = function (grpcStatus){
    switch(grpcStatus){
        case GRPCStatusCodes.InvalidArgument:
            return HTTPStatusCodes.BadRequest;
        case GRPCStatusCodes.Unauthorized:
            return HTTPStatusCodes.Unauthorized;
    }
}