main() {
  print("hello");

  var f = (x)=>x+1;

  print(f(3))

  g(x) {
    return f(x)*2
  }

  print(g(4))

  twice(f,x) => f(f(x))
  //or
  var twice (f,x) => f(f(x))

// => equalts to {return ;}

  print(twice(f,3))
}
