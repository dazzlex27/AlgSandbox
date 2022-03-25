# test1
# [2,7,11,15]
# 9

# test2
# [3,2,4]
# 6

# test3
# [3,3]
# 6

from collections import defaultdict

class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        d = defaultdict(OrderedDict)
        
        i = 0       
        for k in nums:
            d[k][i] = ""
            i += 1
        
        for k in d.keys():
            rem = target - k
            if rem in d:
                d_k = d[k]
                d_rem = d[rem]
                if d_k == d_rem and len(d_k) == 1:
                    continue
                
                first = d_k.popitem(last=False)[0]
                second = d_rem.popitem(last=False)[0]

                return [first, second]
            
        return (-1, -1)