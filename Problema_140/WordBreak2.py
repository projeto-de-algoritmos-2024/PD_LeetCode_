class Solution:
    def wordBreak(self, s, wordDict):
        wordSet = set(wordDict)
        n = len(s)
        dp = [[] for _ in range(n + 1)]  
        dp[0] = ['']  
        for i in range(1, n + 1):
            for j in range(i):
                if s[j:i] in wordSet:
                    for sentence in dp[j]:
                        dp[i].append(sentence + ('' if sentence == '' else ' ') + s[j:i])
        
        return dp[n]

s = "catsanddog"
wordDict = ["cat", "cats", "and", "sand", "dog"]
sol = Solution()
print(sol.wordBreak(s, wordDict))
