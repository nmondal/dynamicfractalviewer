#!/usr/bin/perl

sub GetJump
{
	my $a = @_[0];
	my $x = @_[1];

	if ( $a < 10 )
	{
		$x += -1 ;
	}
	elsif( $a < 20 )
	{
		$x += 0;
	}
	else
	{
		$x += 1;
	}

	if ($x < 0 )
	{
		$x = 0;
	}
	if($x > 255 )
	{
		$x = 255;
	}
	
	$x;

}

sub GenerateRandomMap
{

	
	
	my $range = 30;
	my $r = @_[0] ; #The R
	my $g = @_[1] ; #The G
	my $b = @_[2] ; #The B

   	
		printf ( "%d %d %d\n", $r, $g,$b);

		printf ( "________________\n" );


	for ( $i = 0 ; $i < 256 ; $i++ )
	{
		printf ( "%d %d %d\n", $r, $g,$b);
		$r = GetJump( rand($range), $r );
		$g = GetJump( rand($range), $g );
		$b = GetJump( rand($range), $b );

	}
	
}

GenerateRandomMap( $ARGV[0], $ARGV[1],$ARGV[2] );
