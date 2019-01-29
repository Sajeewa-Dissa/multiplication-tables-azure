var helpingScript = require("./../helper.js");

module.exports = function (context, req) {
    context.log('JavaScript HTTP trigger function processed a request.');

    if ((req.body && req.body.multiple) && (req.body && req.body.modulus)) {
            context.res = {
                body: helpingScript.createMatrix(req.body.multiple, req.body.modulus)
            };
    }
    else {
        context.res = {
            status: 400,
            body: "The message body is missing required params for multiple and modulus."
        };
    }
    context.done();
};