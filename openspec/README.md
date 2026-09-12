# OpenSpec

This folder is an **implementation trail**. It records how features were designed and built. It is not the current product map.

There is no `openspec/specs/` tree. Current maps are:

- [README.md](../README.md) and package READMEs (`web/`)
- [rdp-specifications/](../rdp-specifications/README.md) for customer rules

## How to read a change

Under `changes/` (and `changes/archive/` for finished work):

1. `proposal.md` / `design.md` — why it was done
2. Matching `rdp-specifications/.../implementation-notes.md` — what actually shipped
3. Code — what runs today

Later folders in a cluster supersede earlier ones. Do not implement from an archived change.

## Clusters

Finished foundation work lives in `changes/archive/`.
