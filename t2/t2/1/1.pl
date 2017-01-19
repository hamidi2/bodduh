foreach (<*.sort>) {
	open IF, $_ or die $!;
	open OF, ">$_.rmdup" or die $!;
	undef $last;
	foreach (<IF>) {
		@ar = split /\t/, $_;
		next if $ar[0] eq $last;
		print OF $_;
		$last = $ar[0];
	}
	close OF;
	close IF;
}

