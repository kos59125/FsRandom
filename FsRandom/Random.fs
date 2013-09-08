﻿module FsRandom.Random

open FsRandom.StateMonad

let inline next (generator:GeneratorFunction<_>) = runState generator
let inline get (generator:GeneratorFunction<_>) = evaluateState generator

let inline identity (generator:GeneratorFunction<_>) = generator
let inline transformBy f (generator:GeneratorFunction<_>) =
   fun s0 -> let r, s' = generator s0 in f r, s'
let inline transformBy2 f (g1:GeneratorFunction<_>) (g2:GeneratorFunction<_>) =
   fun s0 ->
      let r1, s1 = g1 s0
      let r2, s2 = g2 s1
      f r1 r2, s2
