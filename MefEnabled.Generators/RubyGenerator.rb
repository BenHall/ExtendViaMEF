require 'MefEnabled.Interfaces'
include MefEnabled::Interfaces

class RubyGenerator < PartDefinition

	include IGenerator
	
	export IGenerator
	
	def get
		['Ruby', 'Ruby2', 'Ruby3']
	end

end