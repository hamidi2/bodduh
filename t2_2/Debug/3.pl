for ($n = 0; $n < 1000; $n++)
{
	for ($k = 0; ; $k++)
	{
		if (($k * 28 + $n) % 11 == 0)
		{
			print "28* $k +$n = 11* ".($k * 28 + $n) / 11 ."\n";
			last;
		}
		if ((($k * 28 - $n) > 0) && ($k * 28 - $n) % 11 == 0)
		{
			print "28* $k -$n = 11* ".($k * 28 - $n) / 11 ."\n";
			last;
		}
	}
}
