# Chapter 7: Functional Parser

## Part 2

### Sequencing
A sequence of parsers can be combined as a single composite parser using the keyword __do__

##### Example
```Haskell
p ∷ Parser (Char,Char)
p = do  x ← item
        item
        y ← item
        return (x,y)
```

##### Note:
- Each parser must begin in precisely the same column. That is, the __layout rule__ applies.
- The values returned by intermediate parsers are __discarded__ by default, but if required can be name using the <- operator.
- The value returned by the __last__ parser is the value returned by the sequence as a whole

If any parser in a sequence of parsers __fails__, then the sequence as a whole __fails__. For example:

```Haskell
> parse p "abcdef"
[(('a','c'),"def")]

> parse p "ab"
[]
```
The do notation is not specific to the Parser type, but can be used with __any__ monadic type

### Derived Primitives
Parsing a character that __satisfies__ a predicate:

```Haskell
sat   ∷ (Char → Book) → Parser Char
sat p = do  x ← item
            if  p x then
                return x
            else
                failure
```

Parsing a __digit__ and specific __characters__:

```Haskell
digit   ∷ Parser Char
digit   = sat isDigit

char    ∷ Char → Parser Char
char x  = sat (x ==)
```

Applying a parser __zero or more__ times:

```Haskell
many    ∷ Parser a → Parser [a]
many p  = many1 p +++ return []
```

Applying a parser __one or more__ times:

``` Haskell
many1   ∷ Parser a → Parser [a]
many1 p = do  v ← p
              vs ← many p
              return (v:vs)
```

Passing a specific __string__ of characters:

```Haskell
string        ∷ String → Parser String
string []     = return []
string (x:xs) = do  char x
                    string xs
                    return (x:xs)
```

#### Example
We can now define a parser that comsumes a list of one or more digits from a string:

```Haskell
p ∷ Parser String
p = do char '['
       d  ← digit
       ds ← many (do char ','
                     digit)
       char ']'
       return (d:ds)

-- examples
> parse p "[1,2,3,4]"
[("1234","")]

> parse p "[1,2,3,4"
[]
```

##### Note:
More sophisticated parsing libraries can indicate and/or recover from __errors__ in the input string.


#### Important point
A sequence of parsers can be combined as a single composite parser using the keyword “do.” Following the layout rule, each parser must begin in the same column. The “do” notation is not specific to the Parser type, but can be used with any monadic type. The main advantage of monads is that you can use the “do” notation.
