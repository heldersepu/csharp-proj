```c
        static int CountBits(int value)
        {
            int count = 0;
            int bit = 1;
            for (int i = 0; i < 8; i++)
            {
                if ((bit & value) == bit)
                    count++;
                bit <<= 1;
            }
            return count;
        }
```
