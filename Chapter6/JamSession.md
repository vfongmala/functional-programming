# Chruch Numeral

Chruch Numerals give us a way to *abstract* over the concrete representation of a number by means of *functions* and *function application*

```Haskell
type Church = (a → a) → a → a

zero  = \s z → z
one   = \s z → s z
two   = \s z → s (s z)
      = \s z → (s . s) z
      = \s   → s . s

// example
c2i x = x (+1) 0
c2i two = (\s z → s (s z)) (+1) 0
        = (+1) ((+1) 0)
        = (+1) 1 = 2

// example
c2s x   = x ('*':) "" -- "*****" = 5
c2s two = (\s z → s (s z)) ('*':) ""
        = ('*':) ('*':"")
        = '*':"*" = "**"
```

## Deriving Addition
```Haskell
x' = c2i x
y' = c2i y

x' + y' = c2i (add x y)
        = x (+1) 0 + c2i y
        = x (+1) (c2i y)
        = x (+1) (y (+1) 0)
        = (\s z → x s (y s z))
        = (add x y) (+1) 0
        = c2i (add x y)
```

## Addition
```Haskell
add x y = \s z → x s (y s z)
```

## Multiplication
```Haskell
2 x 3 = 2 + 2 + 2 = 6

two   = \s → s . s
three = \f →    f    .    f    .    f
six   = \s → (s . s) . (s . s) . (s . s)


Multiplication
mul x y = \s z → x (y s) z
```
