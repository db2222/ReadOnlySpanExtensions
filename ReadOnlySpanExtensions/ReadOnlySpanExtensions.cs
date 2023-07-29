﻿namespace ReadOnlySpanExtensions;

public static class ReadOnlySpanExtensions
{
    /// <summary>
    /// Returns all characters before the given text.
    /// </summary>
    /// <param name="span">Span to search through.</param>
    /// <param name="text">Text to search for.</param>
    /// <param name="startPos">Optional starting position.</param>
    /// <param name="stringComparison">Optional culture & case sensitivity rule.</param>
    public static ReadOnlySpan<char> SpanBefore(this ReadOnlySpan<char> span, ReadOnlySpan<char> text, int startPos = 0, StringComparison stringComparison = StringComparison.Ordinal)
    {
        var index = GetIndex(span, text, startPos, stringComparison);
        return index != -1 ? span[..index] : ReadOnlySpan<char>.Empty;
    }

    /// <summary>
    /// Returns all characters before and including the given text itself.
    /// </summary>
    /// <param name="span">Span to search through.</param>
    /// <param name="text">Text to search for.</param>
    /// <param name="startPos">Optional starting position.</param>
    /// <param name="stringComparison">Optional culture & case sensitivity rule.</param>
    public static ReadOnlySpan<char> SpanBeforeIncluding(this ReadOnlySpan<char> span, ReadOnlySpan<char> text, int startPos = 0, StringComparison stringComparison = StringComparison.Ordinal)
    {
        var index = GetIndex(span, text, startPos, stringComparison);
        return index != -1 ? span[..(index + text.Length)] : ReadOnlySpan<char>.Empty;
    }

    /// <summary>
    /// Returns all characters before the last occurence of the given text.
    /// </summary>
    /// <param name="span">Span to search through.</param>
    /// <param name="text">Text to search for.</param>
    /// <param name="startPos">Optional starting position.</param>
    /// <param name="stringComparison">Optional culture & case sensitivity rule.</param>
    public static ReadOnlySpan<char> SpanBeforeLast(this ReadOnlySpan<char> span, ReadOnlySpan<char> text, int startPos = 0, StringComparison stringComparison = StringComparison.Ordinal)
    {
        var index = GetIndex(span, text, startPos, stringComparison, true);
        return index != -1 ? span[..index] : ReadOnlySpan<char>.Empty;
    }

    /// <summary>
    /// Returns all characters before the last occurence of and including the given text itself.
    /// </summary>
    /// <param name="span">Span to search through.</param>
    /// <param name="text">Text to search for.</param>
    /// <param name="startPos">Optional starting position.</param>
    /// <param name="stringComparison">Optional culture & case sensitivity rule.</param>
    public static ReadOnlySpan<char> SpanBeforeLastIncluding(this ReadOnlySpan<char> span, ReadOnlySpan<char> text, int startPos = 0, StringComparison stringComparison = StringComparison.Ordinal)
    {
        var index = GetIndex(span, text, startPos, stringComparison, true);
        return index != -1 ? span[..(index + text.Length)] : ReadOnlySpan<char>.Empty;
    }

    /// <summary>
    /// Returns all characters before the nth occurence of the given text.
    /// </summary>
    /// <param name="span">Span to search through.</param>
    /// <param name="text">Text to search for.</param>
    /// <param name="count">Expected nth occurence.</param>
    /// <param name="startPos">Optional starting position.</param>
    /// <param name="stringComparison">Optional culture & case sensitivity rule.</param>
    public static ReadOnlySpan<char> SpanBeforeNth(this ReadOnlySpan<char> span, ReadOnlySpan<char> text, int count, int startPos = 0, StringComparison stringComparison = StringComparison.Ordinal)
    {
        var index = FindNthOccurrence(span, text, count, startPos, stringComparison);
        return index != -1 ? span[..index] : ReadOnlySpan<char>.Empty;
    }

    /// <summary>
    /// Returns all characters before the nth occurence of and including the given text itself.
    /// </summary>
    /// <param name="span">Span to search through.</param>
    /// <param name="text">Text to search for.</param>
    /// <param name="count">Expected nth occurence.</param>
    /// <param name="startPos">Optional starting position.</param>
    /// <param name="stringComparison">Optional culture & case sensitivity rule.</param>
    public static ReadOnlySpan<char> SpanBeforeNthIncluding(this ReadOnlySpan<char> span, ReadOnlySpan<char> text, int count, int startPos = 0, StringComparison stringComparison = StringComparison.Ordinal)
    {
        var index = FindNthOccurrence(span, text, count, startPos, stringComparison);
        return index != -1 ? span[..(index + text.Length)] : ReadOnlySpan<char>.Empty;
    }

    /// <summary>
    /// Returns all characters after the given text.
    /// </summary>
    /// <param name="span">Span to search through.</param>
    /// <param name="text">Text to search for.</param>
    /// <param name="startPos">Optional starting position.</param>
    /// <param name="stringComparison">Optional culture & case sensitivity rule.</param>
    public static ReadOnlySpan<char> SpanAfter(this ReadOnlySpan<char> span, ReadOnlySpan<char> text, int startPos = 0, StringComparison stringComparison = StringComparison.Ordinal)
    {
        var index = GetIndex(span, text, startPos, stringComparison);
        return index != -1 ? span[(index + text.Length)..] : ReadOnlySpan<char>.Empty;
    }

    /// <summary>
    /// Returns all characters after and including the given text itself.
    /// </summary>
    /// <param name="span">Span to search through.</param>
    /// <param name="text">Text to search for.</param>
    /// <param name="startPos">Optional starting position.</param>
    /// <param name="stringComparison">Optional culture & case sensitivity rule.</param>
    public static ReadOnlySpan<char> SpanAfterIncluding(this ReadOnlySpan<char> span, ReadOnlySpan<char> text, int startPos = 0, StringComparison stringComparison = StringComparison.Ordinal)
    {
        var index = GetIndex(span, text, startPos, stringComparison);
        return index != -1 ? span[index..] : ReadOnlySpan<char>.Empty;
    }

    /// <summary>
    /// Returns all characters after the last occurence of the given text.
    /// </summary>
    /// <param name="span">Span to search through.</param>
    /// <param name="text">Text to search for.</param>
    /// <param name="startPos">Optional starting position.</param>
    /// <param name="stringComparison">Optional culture & case sensitivity rule.</param>
    public static ReadOnlySpan<char> SpanAfterLast(this ReadOnlySpan<char> span, ReadOnlySpan<char> text, int startPos = 0, StringComparison stringComparison = StringComparison.Ordinal)
    {
        var index = GetIndex(span, text, startPos, stringComparison, true);
        return index != -1 ? span[(index + text.Length)..] : ReadOnlySpan<char>.Empty;
    }

    /// <summary>
    /// Returns all characters after the last occurence of and including the given text itself.
    /// </summary>
    /// <param name="span">Span to search through.</param>
    /// <param name="text">Text to search for.</param>
    /// <param name="startPos">Optional starting position.</param>
    /// <param name="stringComparison">Optional culture & case sensitivity rule.</param>
    public static ReadOnlySpan<char> SpanAfterLastIncluding(this ReadOnlySpan<char> span, ReadOnlySpan<char> text, int startPos = 0, StringComparison stringComparison = StringComparison.Ordinal)
    {
        var index = GetIndex(span, text, startPos, stringComparison, true);
        return index != -1 ? span[index..] : ReadOnlySpan<char>.Empty;
    }

    /// <summary>
    /// Returns all characters after the nth occurence of the given text.
    /// </summary>
    /// <param name="span">Span to search through.</param>
    /// <param name="text">Text to search for.</param>
    /// <param name="count">Expected nth occurence.</param>
    /// <param name="startPos">Optional starting position.</param>
    /// <param name="stringComparison">Optional culture & case sensitivity rule.</param>
    public static ReadOnlySpan<char> SpanAfterNth(this ReadOnlySpan<char> span, ReadOnlySpan<char> text, int count, int startPos = 0, StringComparison stringComparison = StringComparison.Ordinal)
    {
        var index = FindNthOccurrence(span, text, count, startPos, stringComparison);
        return index != -1 ? span[(index + text.Length)..] : ReadOnlySpan<char>.Empty;
    }

    /// <summary>
    /// Returns all characters after the nth occurence of and including the given text itself.
    /// </summary>
    /// <param name="span">Span to search through.</param>
    /// <param name="text">Text to search for.</param>
    /// <param name="count">Expected nth occurence.</param>
    /// <param name="startPos">Optional starting position.</param>
    /// <param name="stringComparison">Optional culture & case sensitivity rule.</param>
    public static ReadOnlySpan<char> SpanAfterNthIncluding(this ReadOnlySpan<char> span, ReadOnlySpan<char> text, int count, int startPos = 0, StringComparison stringComparison = StringComparison.Ordinal)
    {
        var index = FindNthOccurrence(span, text, count, startPos, stringComparison);
        return index != -1 ? span[index..] : ReadOnlySpan<char>.Empty;
    }

    /// <summary>
    /// Returns all characters between the given start and end text.
    /// </summary>
    /// <param name="span">Span to search through.</param>
    /// <param name="startText">Start text to search for.</param>
    /// <param name="endText">End text to search for.</param>
    /// <param name="startPos">Optional starting position.</param>
    /// <param name="stringComparison">Optional culture & case sensitivity rule.</param>
    public static ReadOnlySpan<char> SpanBetween(this ReadOnlySpan<char> span, ReadOnlySpan<char> startText, ReadOnlySpan<char> endText, int startPos = 0, StringComparison stringComparison = StringComparison.Ordinal)
    {
        var (StartIndex, EndIndex) = GetPositionsForBetween(span, startText, endText, startPos, stringComparison);
        return StartIndex != -1 ? span.Slice(StartIndex + startText.Length, EndIndex) : ReadOnlySpan<char>.Empty;
    }

    /// <summary>
    /// Returns all characters between and including the given start and end text themselves.
    /// </summary>
    /// <param name="span">Span to search through.</param>
    /// <param name="startText">Start text to search for.</param>
    /// <param name="endText">End text to search for.</param>
    /// <param name="startPos">Optional starting position.</param>
    /// <param name="stringComparison">Optional culture & case sensitivity rule.</param>
    public static ReadOnlySpan<char> SpanBetweenIncluding(this ReadOnlySpan<char> span, ReadOnlySpan<char> startText, ReadOnlySpan<char> endText, int startPos = 0, StringComparison stringComparison = StringComparison.Ordinal)
    {
        var (StartIndex, EndIndex) = GetPositionsForBetween(span, startText, endText, startPos, stringComparison);
        return StartIndex != -1 ? span.Slice(StartIndex, startText.Length + EndIndex + endText.Length) : ReadOnlySpan<char>.Empty;
    }

    /// <summary>
    /// Returns all characters between the first occurrence of the given start and the last occurrence of the given end text.
    /// </summary>
    /// <param name="span">Span to search through.</param>
    /// <param name="startText">Start text to search for.</param>
    /// <param name="endText">End text to search for.</param>
    /// <param name="startPos">Optional starting position.</param>
    /// <param name="stringComparison">Optional culture & case sensitivity rule.</param>
    public static ReadOnlySpan<char> SpanBetweenOuter(this ReadOnlySpan<char> span, ReadOnlySpan<char> startText, ReadOnlySpan<char> endText, int startPos = 0, StringComparison stringComparison = StringComparison.Ordinal)
    {
        var (StartIndex, EndIndex) = GetPositionsForBetween(span, startText, endText, startPos, stringComparison, true);
        return StartIndex != -1 ? span.Slice(StartIndex + startText.Length, EndIndex) : ReadOnlySpan<char>.Empty;
    }

    /// <summary>
    /// Returns all characters between the first occurrence of the given start and the last occurrence of the given end text and including the texts themselves.
    /// </summary>
    /// <param name="span">Span to search through.</param>
    /// <param name="startText">Start text to search for.</param>
    /// <param name="endText">End text to search for.</param>
    /// <param name="startPos">Optional starting position.</param>
    /// <param name="stringComparison">Optional culture & case sensitivity rule.</param>
    public static ReadOnlySpan<char> SpanBetweenOuterIncluding(this ReadOnlySpan<char> span, ReadOnlySpan<char> startText, ReadOnlySpan<char> endText, int startPos = 0, StringComparison stringComparison = StringComparison.Ordinal)
    {
        var (StartIndex, EndIndex) = GetPositionsForBetween(span, startText, endText, startPos, stringComparison, true);
        return StartIndex != -1 ? span.Slice(StartIndex, startText.Length + EndIndex + endText.Length) : ReadOnlySpan<char>.Empty;
    }

    /// <summary>
    /// Returns the count of the given text.
    /// </summary>
    /// <param name="span">Span to search through.</param>
    /// <param name="text">Text to search for.</param>
    /// <param name="startPos">Optional starting position.</param>
    /// <param name="stringComparison">Optional culture & case sensitivity rule.</param>
    public static int SpanCount(this ReadOnlySpan<char> span, ReadOnlySpan<char> text, int startPos = 0, StringComparison stringComparison = StringComparison.Ordinal)
    {
        var count = 0;
        if (startPos > 0) span = span[startPos..];
        var index = span.IndexOf(text, stringComparison);
        while (index >= 0)
        {
            count++;
            span = span[(index + text.Length)..];
            index = span.IndexOf(text, stringComparison);
        }
        return count;
    }

    private static bool IsValid(ReadOnlySpan<char> span, ReadOnlySpan<char> text, int startPos)
    {
        return span.Length > 0 && text.Length > 0 && startPos >= 0 && startPos < span.Length;
    }
    
    private static int GetIndex(ReadOnlySpan<char> span, ReadOnlySpan<char> text, int startPos, StringComparison stringComparison, bool useLastIndexOf = false)
    {
        if (!IsValid(span, text, startPos)) return -1;
        if (startPos == 0) return useLastIndexOf ? span.LastIndexOf(text, stringComparison) : span.IndexOf(text, stringComparison);
        var index = useLastIndexOf ? span[startPos..].LastIndexOf(text, stringComparison) : span[startPos..].IndexOf(text, stringComparison);
        return index != -1 ? index + startPos : -1;
    }
    
    private static int FindNthOccurrence(ReadOnlySpan<char> span, ReadOnlySpan<char> text, int count, int startPos, StringComparison stringComparison)
    {
        if (!IsValid(span, text, startPos) || count <= 0) return -1;
        var index = startPos;
        for (var i = 0; i < count; i++)
        {
            var foundIndex = span[index..].IndexOf(text, stringComparison);
            if (foundIndex == -1) return -1;
            index += foundIndex;
            if (i < count - 1) index += text.Length;
        }
        return index;
    }

    private static (int StartIndex, int EndIndex) GetPositionsForBetween(ReadOnlySpan<char> span, ReadOnlySpan<char> startText, ReadOnlySpan<char> endText, int startPos, StringComparison stringComparison, bool lastForEndText = false)
    {
        if (endText.Length == 0) return (-1, -1);
        var startIndex = GetIndex(span, startText, startPos, stringComparison);
        if (startIndex == -1) return (-1, -1);
        span = span[(startIndex + startText.Length)..];
        var endIndex = lastForEndText ? span.LastIndexOf(endText, stringComparison) : span.IndexOf(endText, stringComparison);
        if (endIndex == -1) return (-1, -1);
        return (startIndex, endIndex);
    }
}