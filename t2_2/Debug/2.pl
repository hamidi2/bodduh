@ARGV or die "not enough arguments\n";
$n = $ARGV[0];
for ($k = 0; ; $k++)
{
	if (($k * 28 + $n) % 11 == 0)
	{
		print "\n28 * $k = ". 28 * $k ."\n";
		print 28 * $k ." + $n = ". ($k * 28 + $n) ."\n";
		print $k * 28 + $n ." = 11 * ". ($k * 28 + $n) / 11 ."\n";
		print "\n28 * $k + $n = 11 * ".($k * 28 + $n) / 11 ."\n";
		last;
	}
	if (($k * 28 - $n) % 11 == 0)
	{
		print "\n28 * $k = ". 28 * $k ."\n";
		print 28 * $k ." - $n = ". ($k * 28 - $n) ."\n";
		print $k * 28 - $n ." = 11 * ". ($k * 28 - $n) / 11 ."\n";
		print "\n28 * $k - $n = 11 * ".($k * 28 - $n) / 11 ."\n";
		last;
	}
}
