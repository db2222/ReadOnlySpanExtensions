# ReadOnlySpanExtensions
Available via Nuget: https://www.nuget.org/packages/ReadOnlySpanExtensions

Little convenience helper extension methods for slicing `ReadOnlySpan` (C#) via texts.\
All available extension methods start with `Span` in their name.

# Extension methods
## SpanBefore
Returns all characters before the given text.

Example:
<table>
    <tr><th>span</th><th>text</th><th>Return value</th></tr>
    <tr><td>Test1/Test2</td><td>/</td><td>Test1</td></tr>
</table>

## SpanBeforeIncluding
Returns all characters before and including the given text itself.

Example:
<table>
    <tr><th>span</th><th>text</th><th>Return value</th></tr>
    <tr><td>Test1/Test2</td><td>/</td><td>Test1/</td></tr>
</table>

## SpanBeforeLast
Returns all characters before the last occurence of the given text.

Example:
<table>
    <tr><th>span</th><th>text</th><th>Return value</th></tr>
    <tr><td>Test1/Test2</td><td>Test</td><td>Test1/</td></tr>
</table>

## SpanBeforeLastIncluding
Returns all characters before the last occurence of and including the given text itself.

Example:
<table>
    <tr><th>span</th><th>text</th><th>Return value</th></tr>
    <tr><td>Test1/Test2</td><td>Test</td><td>Test1/Test</td></tr>
</table>

## SpanBeforeNth
Returns all characters before the nth occurence of the given text.

Example:
<table>
    <tr><th>span</th><th>text</th><th>count</th><th>Return value</th></tr>
    <tr><td>Test1/Test2/Test3</td><td>Test</td><td>3</td><td>Test1/Test2/</td></tr>
</table>

## SpanBeforeNthIncluding
Returns all characters before the nth occurence of and including the given text itself.

Example:
<table>
    <tr><th>span</th><th>text</th><th>count</th><th>Return value</th></tr>
    <tr><td>Test1/Test2/Test3</td><td>Test</td><td>3</td><td>Test1/Test2/Test</td></tr>
</table>

## SpanAfter
Returns all characters after the given text.

Example:
<table>
    <tr><th>span</th><th>text</th><th>Return value</th></tr>
    <tr><td>Test1/Test2</td><td>/</td><td>Test2</td></tr>
</table>

## SpanAfterIncluding
Returns all characters after and including the given text itself.

Example:
<table>
    <tr><th>span</th><th>text</th><th>Return value</th></tr>
    <tr><td>Test1/Test2</td><td>/</td><td>/Test2</td></tr>
</table>

## SpanAfterLast
Returns all characters after the last occurence of the given text.

Example:
<table>
    <tr><th>span</th><th>text</th><th>Return value</th></tr>
    <tr><td>Test1/Test2</td><td>Test</td><td>2</td></tr>
</table>

## SpanAfterLastIncluding
Returns all characters after the last occurence of and including the given text itself.

Example:
<table>
    <tr><th>span</th><th>text</th><th>Return value</th></tr>
    <tr><td>Test1/Test2</td><td>Test</td><td>Test2</td></tr>
</table>

## SpanAfterNth
Returns all characters after the nth occurence of the given text.

Example:
<table>
    <tr><th>span</th><th>text</th><th>count</th><th>Return value</th></tr>
    <tr><td>Test1/Test2/Test3</td><td>Test</td><td>3</td><td>3</td></tr>
</table>

## SpanAfterNthIncluding
Returns all characters after the nth occurence of and including the given text itself.

Example:
<table>
    <tr><th>span</th><th>text</th><th>count</th><th>Return value</th></tr>
    <tr><td>Test1/Test2/Test3</td><td>Test</td><td>3</td><td>Test3</td></tr>
</table>

## SpanBetween
Returns all characters between the given start and end text.

Example:
<table>
    <tr><th>span</th><th>startText</th><th>endText</th><th>Return value</th></tr>
    <tr><td>&lt;td&gt;Dummy1&lt;/td&gt;&lt;td&gt;Dummy2&lt;/td&gt;</td><td>&lt;td&gt;</td><td>&lt;/td&gt;</td><td>Dummy1</td></tr>
</table>

## SpanBetweenIncluding
Returns all characters between and including the given start and end text themselves.

Example:
<table>
    <tr><th>span</th><th>startText</th><th>endText</th><th>Return value</th></tr>
    <tr><td>&lt;td&gt;Dummy1&lt;/td&gt;&lt;td&gt;Dummy2&lt;/td&gt;</td><td>&lt;td&gt;</td><td>&lt;/td&gt;</td><td>&lt;td&gt;Dummy1&lt;/td&gt;</td></tr>
</table>

## SpanBetweenOuter
Returns all characters between the first occurrence of the given start and the last occurrence of the given end text.

Example:
<table>
    <tr><th>span</th><th>startText</th><th>endText</th><th>Return value</th></tr>
    <tr><td>&lt;td&gt;Dummy1&lt;/td&gt;&lt;td&gt;Dummy2&lt;/td&gt;</td><td>&lt;td&gt;</td><td>&lt;/td&gt;</td><td>Dummy1&lt;/td&gt;&lt;td&gt;Dummy2</td></tr>
</table>

## SpanBetweenOuterIncluding
Returns all characters between the first occurrence of the given start and the last occurrence of the given end text and including the texts themselves.

Example:
<table>
    <tr><th>span</th><th>startText</th><th>endText</th><th>Return value</th></tr>
    <tr><td>&lt;td&gt;Dummy1&lt;/td&gt;&lt;td&gt;Dummy2&lt;/td&gt;</td><td>&lt;td&gt;</td><td>&lt;/td&gt;</td><td>&lt;td&gt;Dummy1&lt;/td&gt;&lt;td&gt;Dummy2&lt;/td&gt;</td></tr>
</table>

# Further remarks
See the tests for further examples.\
\
In general all methods have an optional `startPos` parameter in case searching should not start at 0 (beginning). Beware that for the `SpanBeforeXXX` methods this only influences the search position but not the outcome. Meaning the characters before `startPos` are included in a possible result.