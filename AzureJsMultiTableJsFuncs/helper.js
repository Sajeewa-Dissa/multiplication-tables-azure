module.exports = {
  createCoords: function (x0, y0, radius, modulus) {
      // coordinates will be calculated from the 9 0'clock position as being the start (so we move 180 degrees around the circle by reflecting each point about the centre)
      var myCoords = [];                        // array to hold circular coordinates;
      for (var i = 0; i < modulus; i++) {
          var x = Math.abs((x0 + radius * Math.cos(2 * Math.PI * i / modulus) - 2 * x0).toFixed(2));  //returns string x coord
          var y = Math.abs((y0 + radius * Math.sin(2 * Math.PI * i / modulus) - 2 * y0).toFixed(2));  //returns string y coord
          myCoords.push([x, y]);
      }
      return JSON.stringify(myCoords);            // return as a JSON object string
  },

  createMatrix: function (multiple, modulus) {
      var myMatrix = [];                         // array to hold multiplication results matrix;
      for (var i = 0; i < modulus; i++) {
          var result = (i * multiple) % modulus;
          myMatrix.push([i, result])
      }
       return JSON.stringify(myMatrix);           // return as a JSON object string
  }
  };
  