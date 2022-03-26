# [] = 0
# [0] = 0
# [1] = 0
# [0, 1] = 1
# [1, 0] = 1
# [1, 1, 1] = 2
# [0, 1, 1] = 2
# [1, 0, 1] = 2
# [1, 1, 0] = 2
# [0, 0, 0] = 0
# [1, 0, 0, 1] = 1
# [0, 1, 1, 0] = 2
# [1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1] = 5

def FindLongestOnesSequence(nums_list):
    if len(num_list) < 2:
        return 0
    
    max = 0
    i = 0
    cur_max = 0
    last_max_before_zero = 0
    zeroes_count = 0
    
    while i < (len(num_list) - 1):
        if nums_list[i] == 1:
            # build current sequence of "1"'s
            cur_max += 1
            total_cur_max = cur_max + last_max_before_zero
            if total_cur_max > max:
                max = total_cur_max
        else:
            # found a different character (not a "1"), resetting some data...
            last_max_before_zero = cur_max
            cur_max = 0
            zeroes_count += 1
            
        i += 1
        
    if zeroes_count == 0
        return len(num_list) - 1
        
    return max