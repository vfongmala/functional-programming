# Chapter 7: Functional Parser

## Part 1

### Introduction
A __parser__ is a program the analyses a piece of text to determine its __syntactic structure__

### The Parser Type
In a functional language such as Haskell, parsers can naturally be viewed as __functions__

```Haskell
-- A parser us a function that takes a string and return some form of tree.
type Parser = String → Tree
```

However, a parser might not require all of its input string, so we also return any __unused input__

```Haskell
type Parser = String -> (Tree, String)
```

A string might be parsable in many ways, including none, so we generalize to a __list of results__

```Haskell
type Parser = String → [(Tree,String)]
```

Finally, a parser might not always produce a tree, so we generalize to a value of __any type__

```Haskell
type Parser a = String → [(a, String)]
```

##### Note:
- For simplicity, we will only consider parsers that either fail and return the empty list of result, or succeed and return a __singleton list__


### Basic Parser
The parser __item__ fails if the input is empty, and consumes the first character otherwise:

```Haskell
item ∷ Parser Char
item = \ inp → case inp of
                []      → []
                (x:xs)  → [(x,xs)]
```

The parser __failure__ always fails:

```Haskell
failure ∷ Parser a
failure = \ inp → []
```

The parser __return v__ always succeeds, returning the value v without consuming any input:

```Haskell
return ∷ a → Parser a
return v = \ input → [(v,inp)]
```

The parser __p +++ q__ behaves as the parser p if it succeeds, and as the parser q otherwise:

```Haskell
(+++)   ∷ Parser a → Parser a → Parser a
p +++ q = \ inp → case p inp of
                    -- if parser p fails then use parser q
                    []        → parse q input
                    -- if parser p succeed then return value
                    [(v,out)] → [(v,out)]
```

The function __parser__ applies a parser to a string:

```Haskell
parse ∷ Parser a → String → [(a,String)]
parse p inp = p inp
```

#### Example
The behavior of the five parsing primitive can be illustrated with some simple __example__

```Haskell
% ghci Parsing

> parse item ""
[]

> parse item "abc"
[('a',"bc")]

> parse failure "abc"
[]

> parse (return 1) "abc"
[(1, "abc")]

> parse (item +++ return 'd') "abc"
[('a', "bc")]

> parse (failure +++ return 'd') "abc"
[('d', "abc")]
```

##### Note:
- The library file __Parsing__ is available on the web from the Programming in Haskell home page
- For technical reasons, the first failure example actually gives an error concerning __types__, but this does not occur in non-trivial examples.
- The Parser type is a __monad__, a mathematical structure that has proved useful for modeling many different kinds of computation.


### Important points
A parser analyses a piece of text and extracts structure from it. Parsers are functions that take a string and usually return some form of tree and (optionally) any unused input. Since a string may be parsable in many ways, including none, returned can also be a list of trees. The “failure” parser always fails; the “return v” parser always succeeds and returns the value “v” without consuming any input. The “p +++ q” parser behaves as the parser “p” if it succeeds and the parser “q” if it does not.
