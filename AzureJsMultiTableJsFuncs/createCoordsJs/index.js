var helpingScript = require("./../helper.js");

module.exports = function (context, req) {
    context.log('JavaScript HTTP trigger function processed a request.');

    if ((req.body && req.body.x0) && (req.body && req.body.y0) &&
            (req.body && req.body.radius) && (req.body && req.body.modulus)) {
            context.res = {
                body: helpingScript.createCoords(req.body.x0, req.body.y0, req.body.radius, req.body.modulus)
            };
    }
    else {
        context.res = {
            status: 400,
            body: "The message body is missing required params for x0, y0, radius and modulus."
        };
    }
    context.done();
};