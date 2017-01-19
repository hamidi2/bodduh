#!/usr/bin/perl
# sorts dat files into db files

sub sortFunc
{
	my @ar_a = split (/\s+/, $a);
	my @ar_b = split (/\s+/, $b);
	return -1 if length($ar_a[0]) < length($ar_b[0]);
	return 1 if length($ar_a[0]) > length($ar_b[0]);
	return -1 if length($ar_a[1]) < length($ar_b[1]);
	return 1 if length($ar_a[1]) > length($ar_b[1]);
	return -1 if $ar_a[0] < $ar_b[0];
	return 1 if $ar_a[0] > $ar_b[0];
	return -1 if $ar_a[1] < $ar_b[1];
	return 1 if $ar_a[1] > $ar_b[1];
	return 0;
}

sub sortFunc2
{
	my @ar_a = split (/\s+/, $a);
	my @ar_b = split (/\s+/, $b);
	return ($ar_b[4] + $ar_b[6]) <=> ($ar_a[4] + $ar_a[6]);
}

for $i ("01".."28") {
	print "$i\n";
	open IF, "sum-$i.dat" or die $!;
	@lines = sort sortFunc <IF>;
	close IF;
	open OF, ">sum-$i.db" or die $!;
	print OF @lines;
	close OF;
}
