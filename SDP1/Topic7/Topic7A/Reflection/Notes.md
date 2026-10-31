No, I didn't need to call .Sort(). SortedSet keeps itself in order automatically, so every time I add a score it gets put in the right place straight away. Even when I added 9999 it went straight to the end without me doing anything.

SortedSet uses a self-balancing binary search tree (a red-black tree) underneath. 

When I added the duplicate score (9999), Add() returned false and the score wasn't added, so the set still had 11 scores. A SortedSet is a set, so every value has to be unique. When it compares the new value to what's already in the tree and finds one that's equal, it just ignores it.
