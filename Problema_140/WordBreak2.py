def wordBreak(s, wordDict):
    wordSet = set(wordDict)  
    result = []
    

    for i in range(1, len(s) + 1):
        if s[:i] in wordSet: 
            result.append(s[:i]) 
            
    return result

s = "catsanddog"
wordDict = ["cat", "cats", "and", "sand", "dog"]
print(wordBreak(s, wordDict))
