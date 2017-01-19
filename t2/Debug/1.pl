# remove "set #" and "are in the same set" columns from dat files

foreach (<*.dat>) {
	open IF, $_ or die $!;
	open OF, ">tmp" or die $!;
	foreach (<IF>) {
		@ar = split;
		splice @ar, 2, 2;
		print OF "@ar\n";
	}
	close IF or die $!;
	close OF or die $!;
	unlink $_;
	rename "tmp", $_;
}
