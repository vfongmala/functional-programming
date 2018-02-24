Chapter 1: First Step

Part 2
* All base on Haskell language

Script
- use .hs extension
- start GHCI with the script by
  ghci `<script file name>.hs`
- function in the script will be available in the command prompt

Commands
- `:reload` -> command to reload file
- `:load <script name>` -> load script
- `:edit <script name>` -> edit script
- `:edit` -> edit current script
- `:type or :t expr` -> show type of expr
- `:?` -> show all commands
- `:quit` -> quit GHCI

Functions
- `fst (x,y)` -> first argument
- `snd (x,y)` -> second argument
- `div (x,y)` -> divide x by y

Boolean
- `True False` use upper-case
- `not <Bool>` invert of <Bool> value

Naming Requirement
- must start with lower-case
- type start with upper-case
- list argument always have 's' suffix ie. `xs` `ns`

Layout rule (kinda same as python)
- Definitions must begin with same column (whitespace has effect)
``` Haskell
a = 1
b = 2
c = 3
```
is correct

``` Haskell
a = 1
 b = 2
c = 3
```
is wrong

- indent means grouping
``` Haskell
a = b + c
    where
      b = 1
      c = 2
d = a * 2
```
is same as
``` Haskell
a = b + c
    where
      {b = 1;
       c = 2}
d = a * 2
```

Note:
- ```x `f` y``` => f x y (it's just for readability)
