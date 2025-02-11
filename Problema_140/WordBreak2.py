def wordBreak(s, wordDict):
    wordSet = set(wordDict)
    result = []
    
    def backtrack(start, current):
        
        if start == len(s):
            result.append(" ".join(current))
            return
        
        
        for end in range(start + 1, len(s) + 1):
            if s[start:end] in wordSet:
                backtrack(end, current + [s[start:end]])  

    backtrack(0, [])
    return result


s = "catsanddog"
wordDict = ["cat", "cats", "and", "sand", "dog"]
print(wordBreak(s, wordDict))
