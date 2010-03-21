require 'MefEnabled.Interfaces'
include MefEnabled::Interfaces

class RubyGenerator < PartDefinition

	include IGenerator
	
	export IGenerator
	
	def get
		%W(This is an array of characters to output for data generation)
	end

end