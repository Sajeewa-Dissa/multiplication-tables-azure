module.exports = function (context, req) {
    context.log('JavaScript HTTP trigger function processed a request.');

    if (req.body && req.body.value) {
        context.res = {
            // status: 200, /* Defaults to 200 */
            body: "Hello " + (req.body.value)
        };
    }
    else {
        context.res = {
            status: 400,
            body: "Please pass a value in the request body"
        };
    }
    context.done();
};
