
var x = new List<int?> { 1, null, 3 };
var y = new List<int?> { 2, null, 3 };
var z = (from xx in x
         join yy in y on new { a = xx } equals new { a = yy }
         select new { xx, yy }).ToList();
var zz = (from xx in x
          join yy in y on xx equals yy
          select new { xx, yy }).ToList();

var m = 1;
