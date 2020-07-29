# ProxyDupeRemover
This is a duplicates remover that runs quick and fast using threading.

Simple to use just place proxies.txt in the same folder as the ProxyDupeRemover console application and run it.

It will read the proxies.txt file (won't overwrite it) and will start to process it...

You will get live updates in the console app as it's processing through the list and removing duplicates.

After it's done removing duplicates in the same folder it will save a fixed copy as proxies-fixed.txt

This was a quick hack n slash write up based on some example code that I had to use threading for because it's too slow without threading.
