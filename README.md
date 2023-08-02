# ReadOnlySpanExtensions (C#)
Available via Nuget: https://www.nuget.org/packages/ReadOnlySpanExtensions \
\
Little convenience helper extension methods for slicing `ReadOnlySpan` (C#) via texts.\
All available extension methods start with `Span` in their name.

# Extension methods
## SpanBefore
Returns all characters before the given text.

### Example
span | text | Return value
-----|------|-------------
`Test1/Test2` | `/` | `Test1`

## SpanBeforeIncluding
Returns all characters before and including the given text itself.

### Example
span | text | Return value
-----|------|-------------
`Test1/Test2` | `/` | `Test1/`

## SpanBeforeLast
Returns all characters before the last occurence of the given text.

### Example
span | text | Return value
-----|------|-------------
`Test1/Test2` | `Test` | `Test1/`

## SpanBeforeLastIncluding
Returns all characters before the last occurence of and including the given text itself.

### Example
span | text | Return value
-----|------|-------------
`Test1/Test2` | `Test` | `Test1/Test`

## SpanBeforeNth
Returns all characters before the nth occurence of the given text.

### Example
span | text | count | Return value
-----|------|-------|-------------
`Test1/Test2/Test3` | `Test` | `3` | `Test1/Test2/`

## SpanBeforeNthIncluding
Returns all characters before the nth occurence of and including the given text itself.

### Example
span | text | count | Return value
-----|------|-------|-------------
`Test1/Test2/Test3` | `Test` | `3` | `Test1/Test2/Test`

## SpanAfter
Returns all characters after the given text.

### Example
span | text | Return value
-----|------|-------------
`Test1/Test2` | `/` | `Test2`

## SpanAfterIncluding
Returns all characters after and including the given text itself.

### Example
span | text | Return value
-----|------|-------------
`Test1/Test2` | `/` | `/Test2`

## SpanAfterLast
Returns all characters after the last occurence of the given text.

### Example
span | text | Return value
-----|------|-------------
`Test1/Test2` | `Test` | `2`

## SpanAfterLastIncluding
Returns all characters after the last occurence of and including the given text itself.

### Example
span | text | Return value
-----|------|-------------
`Test1/Test2` | `Test` | `Test2`

## SpanAfterNth
Returns all characters after the nth occurence of the given text.

### Example
span | text | count | Return value
-----|------|-------|-------------
`Test1/Test2/Test3` | `Test` | `3` | `3`

## SpanAfterNthIncluding
Returns all characters after the nth occurence of and including the given text itself.

### Example
span | text | count | Return value
-----|------|-------|-------------
`Test1/Test2/Test3` | `Test` | `3` | `Test3`

## SpanBetween
Returns all characters between the given start and end text.

### Example
span | startText | endText | Return value
-----|-----------|---------|-------------
`<td>Dummy1</td><td>Dummy2</td>` | `<td>` | `</td>` | `Dummy1`

## SpanBetweenIncluding
Returns all characters between and including the given start and end text themselves.

### Example
span | startText | endText | Return value
-----|-----------|---------|-------------
`<td>Dummy1</td><td>Dummy2</td>` | `<td>` | `</td>` | `<td>Dummy1</td>`

## SpanBetweenOuter
Returns all characters between the first occurrence of the given start and the last occurrence of the given end text.

### Example
span | startText | endText | Return value
-----|-----------|---------|-------------
`<td>Dummy1</td><td>Dummy2</td>` | `<td>` | `</td>` | `Dummy1</td><td>Dummy2`

## SpanBetweenOuterIncluding
Returns all characters between the first occurrence of the given start and the last occurrence of the given end text and including the texts themselves.

### Example
span | startText | endText | Return value
-----|-----------|---------|-------------
`<td>Dummy1</td><td>Dummy2</td>` | `<td>` | `</td>` | `<td>Dummy1</td><td>Dummy2</td>`

## SpanCount
Returns the count of the given text.

### Example
span | text | Return value
-----|------|-------------
`Test1/Test2/Test3` | `Test` | `3`

## SpanPairSurrounding
Returns both spans before the given start and after the end text.

### Example
span | startText | endText | Return value
-----|-----------|---------|-------------
`<table><tr><td>Dummy</td></tr></table>` | `<tr>` | `</tr>` | `<table>` / `</table>`

## SpanPairSurroundingIncluding
Returns both spans before the given start and after the end text including the texts themselves.

### Example
span | startText | endText | Return value
-----|-----------|---------|-------------
`<table><tr><td>Dummy</td></tr></table>` | `<tr>` | `</tr>` | `<table><tr>` / `</tr></table>`

## SpanPairSurroundingOuter
Returns both spans before the first occurrence of the given start and after the last occurrence of the end text.

### Example
span | startText | endText | Return value
-----|-----------|---------|-------------
`<table><tr><td>Dummy1</td><td>Dummy2</td></tr></table>` | `<td>` | `</td>` | `<table><tr>` / `</tr></table>`

## SpanPairSurroundingOuterIncluding
Returns both spans before the first occurrence of the given start and after the last occurrence of the end text including the texts themselves.

### Example
span | startText | endText | Return value
-----|-----------|---------|-------------
`<table><tr><td>Dummy1</td><td>Dummy2</td></tr></table>` | `<td>` | `</td>` | `<table><tr><td>` / `</td></tr></table>`

# Further remarks
See the tests for further examples.\
\
In general all methods have an optional `startPos` parameter in case searching should not start at 0 (beginning). Beware that for the `SpanBeforeXXX` methods this only influences the search position but not the outcome. Meaning the characters before `startPos` are included in a possible result.\
\
Furthermore all methods have an optional `stringComparison` parameter to configure the culture & case sensitivity behaviour. The default value is `Ordinal`. Meaning compare strings using ordinal (binary) sort rules.