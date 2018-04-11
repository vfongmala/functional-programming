# Chapter 7: Functional Parser

## Part 3

### Arithmetic Expressions

Consider a simple form of __expressions__ built up from single digits using the operations of addition + and multiplication * , together with parentheses.

We also assume that:
- * and + associate to the right;
- * has higher priority than +.

Formally, the syntax of such expressions is defined by the following context free __grammar__:

``` Haskell
expr    → term '+' expr | term
term    → factor '*' term | factor
factor  → digit | '(' expr ')'
digit   → '0' | '1' | ... | '9'
```

However, for reasons of efficiency, it is important to __factorise__ the rules for *expr* and *term*:

```Haskell
expr → term ('+' expr | ε)

term → factor ('*' term | ε)
-- The symbol ε denotes the empty string

```

It is now easy to translate the grammar into a parser that __evaluates__ expressions, by simply rewriting the grammar rules using the parsing primitives.

```Haskell
expr ∷ Parser Int
expr = do t ← term
          do char '+'
             e ← expr
             return (t + e)
          +++ return t
```

```Haskell
term ∷ Parser Int
term = do f ← factor
          do char '*'
             t ← term
             return (f * t)
          +++ return f
```

```Haskell
factor ∷ Parser Int
factor = do d ← digit
            return (digitToInt d)
            +++ do char '('
                   e ← expr
                   char ')'
                   return e
```

```Haskell
eval    ∷ String → Int
eval xs = fst (head (parse expr xs))
```

#### Example
```Haskell
> eval "2*3+4"
10

> eval "2*(3+4)"
14
```

### Important Points
Arithmetic expressions are formally defined by a context-free grammar. However, for efficiency reasons, it is important to factorise the rules for “expr” and “term.” By rewriting the grammar rules using the parsing primitives it becomes easy to translate the grammar into a parser that evaluates expressions. 
