def wordBreak(s, wordDict):
    wordSet = set(wordDict)
    memo = {}
    
    def backtrack(start):
        
        if start in memo:
            return memo[start]
        
    
        if start == len(s):
            return ['']
        
        result = []
        
        
        for end in range(start + 1, len(s) + 1):
            if s[start:end] in wordSet:
                rest_of_sentences = backtrack(end)
                for sentence in rest_of_sentences:
                    result.append(s[start:end] + ('' if sentence == '' else ' ' + sentence))
        
    
        memo[start] = result
        return result
    

    return backtrack(0)


s = "catsanddog"
wordDict = ["cat", "cats", "and", "sand", "dog"]
print(wordBreak(s, wordDict))
